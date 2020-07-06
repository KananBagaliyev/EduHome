using BackEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AboutSlider> AboutSliders { get; set; }
        public DbSet<AboutTeacher> AboutTeachers { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CenterPhoneNumber> CenterPhoneNumbers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<CourseFeature> CourseFeatures { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<NoticeVideo> NoticeVideos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherHobby> TeacherHobbies { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
