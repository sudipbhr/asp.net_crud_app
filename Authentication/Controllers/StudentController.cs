using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using MailKit;
using MailKit.Net.Smtp;


using MimeKit;
using PagedList;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Authentication.Controllers
{

    public class StudentController : Controller
    {
        private readonly AuthenticationContext authenticateDb;

        public StudentController(AuthenticationContext authenticateDb)
        {
            this.authenticateDb = authenticateDb;

        }
        public IActionResult Index(int? page)
        {
            var students = authenticateDb.Students.ToList(); // Retrieve all students from the database
            int pageSize = 1;
            int pageNumber = page ?? 1; // If page is null, default to page 1

            // Create a paged list of students
            var pagedStudents = students.ToPagedList(pageNumber, pageSize);
            var posts = authenticateDb.Posts.ToList();

            ViewBag.pagedStudents = pagedStudents;
            ViewBag.posts = posts;  

            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string toEmail, string subject, string body)
        {

            if (string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                ModelState.AddModelError("", "Please provide all required fields.");
                return View("SendEmail"); // Consider returning appropriate view here.
            }

            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Sender Name", "sudipbhandari67@gmail.com"));
                email.To.Add(new MailboxAddress("Receiver Name", toEmail));
                email.Subject = subject;
                email.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);
                    smtp.Authenticate("sudipbhandari67@gmail.com", "vymp gnbr xbsp dovj");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                return View("SendEmail"); // Return success view
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ModelState.AddModelError("", $"Failed to send email: {ex.Message}");
                return View(); // Consider returning appropriate view here.
            }

        }
    }
}