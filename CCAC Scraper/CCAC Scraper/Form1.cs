using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using AngleSharp.Parser.Html;
using AngleSharp.Dom.Html;
using AngleSharp.Dom;

namespace CCAC_Scraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            deleteFiles();
        }

        List<string> subjectCodes = null;
        List<string> subjectName = null;
        List<string> courseCodes = null;

        private IDictionary<string, object> getCourses(string subjectCode)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();

            List<string> courses = new List<string>();
            List<string> labels = new List<string>();

            string coursesURL = @"https://webapps.ccac.edu/mastersyllabi/GetCourses/tabid/57/Default.aspx?subject=" + subjectCode;

            string html = getHTML(coursesURL);

            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = parser.Parse(html);
            IElement coursesTable = doc.GetElementById("dnn_ctr375_ContentPane");

            IHtmlCollection<IElement> courseUrls = coursesTable.GetElementsByTagName("a");
            IHtmlCollection<IElement> courseLabels = coursesTable.GetElementsByClassName("Normal");

            
            int i = 0;

            foreach(IElement url in courseUrls)
            {
                // Skip the last one
                if (i != courseUrls.Length - 1)
                {
                    courses.Add(url.GetAttribute("href"));
                }
                i++;
            }

            int urlCounter = 0;

            foreach (IElement label in courseLabels)
            {
                labels.Add(label.TextContent);

                if (labels.Count == 3)
                {
                    dict.Add(courses[urlCounter], labels);
                    urlCounter++;
                    labels = new List<string>();
                }
            }

            return dict;
        }

        private IDictionary<string, object> getSubjects()
        {

            IDictionary<string, object> dict = new Dictionary<string, object>();
            List<string> codes = new List<string>();
            List<string> subjectURLS = new List<string>();
            List<string> list;

            string subjectsURL = @"https://webapps.ccac.edu/mastersyllabi/GetCourses/tabid/57/Default.aspx?division=C";

            string html = getHTML(subjectsURL);

            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = parser.Parse(html);
            IElement subjectsTable = doc.GetElementById("dnn_ctr375_GetCourse_dgSubjects");

            IHtmlCollection<IElement> subjects = subjectsTable.GetElementsByClassName("CommandButton");

            foreach (IElement subject in subjects)
            {
                codes.Add(subject.TextContent.ToString());
                subjectURLS.Add(subject.LastElementChild.GetAttribute("href"));
            }

            // Separate the codes and courses
            IDictionary<string, string> codesAndCourses = parseCodes(codes);

            int i = 0;

            foreach(KeyValuePair<string, string> kvp in codesAndCourses)
            {
                list = new List<string>();
                list.Add(kvp.Key);
                list.Add(kvp.Value);

                dict.Add(subjectURLS[i], list);
                i++;
            }

            return dict;
        }

        public IDictionary<string, string> parseCodes(List<string> codes)
        {
            IDictionary<string, string> codesAndCourses = new Dictionary<string, string>();

            foreach (string cd in codes)
            {
                // Get first space
                int space = cd.IndexOf(' ');

                // Parse
                string course = cd.Substring(space);

                // Clean up
                if(course.StartsWith(" ")){
                    course = course.Remove(0, 1);
                }

                // Parse
                string code = cd.Remove(cd.Length - course.Length);

                // Clean up
                code = code.Replace(" ", "");

                // Add results
                codesAndCourses.Add(code, course);
            }

            return codesAndCourses;
        }

        private string getHTML(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader read = new StreamReader(stream, Encoding.UTF8);
            string html = read.ReadToEnd();
            return html;
        }
        
        private byte[] getFile(string url)
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            WebResponse resp = req.GetResponse();

            Stream stream = resp.GetResponseStream();
            byte[] bytes = convertToBytes(stream);

            return bytes;
        }
        private string saveFile(string filename, byte[] bytes)
        {
            string projectFolder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
            string filepath = Path.Combine(projectFolder, "Temporary Internet Files") + @"\" + filename;
            File.WriteAllBytes(filepath, bytes);

            return filepath;
        }

        private void deleteFiles()
        {
            string projectFolder = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
            string folderPath = Path.Combine(projectFolder, "Temporary Internet Files");

            string[] filePaths = Directory.GetFiles(folderPath);
            
            foreach(string filePath in filePaths)
            {
                File.Delete(filePath);
            }
        }

        private byte[] convertToBytes(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private void getSubjects_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> subjects = getSubjects();

            List<string> subjectURLs = new List<string>();
            subjectCodes = new List<string>();
            subjectName = new List<string>();

            foreach (KeyValuePair<string, object> subject in subjects)
            {

                List<string> dict = (List<string>)subject.Value;

                subjectURLs.Add(subject.Key);
                subjectCodes.Add(dict[0]);
                subjectName.Add(dict[1]);

            }

            listBox_Subjects.DataSource = subjectName;

        }
    
        private void btnGetSyllabus_Click(object sender, EventArgs e)
        {
            if (dtg_Courses.DataSource != null)
            {
                int selectedClass = dtg_Courses.CurrentCell.RowIndex;

                string code = courseCodes[selectedClass];

                string url = @"https://webapps.ccac.edu/mastersyllabi/GetCourses/tabid/57/Default.aspx?course=" + code;
                byte[] bytes = getFile(url);

                string filename = code + ".pdf";

                string filepath = saveFile(filename, bytes);

                webBrowser.Navigate(filepath);
            }
        }

        private void btnGetClasses_Click(object sender, EventArgs e)
        {
            if (listBox_Subjects.DataSource != null)
            {
                int selectedSubject = listBox_Subjects.SelectedIndex;

                IDictionary<string, object> courses = getCourses(subjectCodes[selectedSubject]);

                courseCodes = new List<string>();

                DataTable table = new DataTable();
                table.Columns.Add("Code");
                table.Columns.Add("Name");
                table.Columns.Add("Last Updated");

                foreach (KeyValuePair<string, object> course in courses)
                {
                    List<string> dict = (List<string>)course.Value;
                    table.Rows.Add(dict[0], dict[1], dict[2]);
                    courseCodes.Add(dict[0]);
                }

                dtg_Courses.DataSource = table;
            }
        }
    }
}
