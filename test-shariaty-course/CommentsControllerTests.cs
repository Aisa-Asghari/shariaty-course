using Microsoft.AspNetCore.Mvc;
using Moq;
using shariaty_course.Controllers;
using shariaty_course.Models;

namespace test_shariaty_course
{
    public class CommentsControllerTests
    {
        private readonly Mock<ICommentService> _mockCommentService = new Mock<ICommentService>();
        private readonly CommentsController _controller;

        public CommentsControllerTests()
        {
            _controller = new CommentsController(_mockCommentService.Object);
        }

        [Fact]
        public void GetComments_ReturnsOkResult_WithListOfComments()
        {
            var expectedComments = new List<Comment>
            {
                new Comment {
                    Id = 1,
                    Professor= "منیره نیک اختر",
                    Field= "نرم افزار",
                    Course= "آزمایشگاه سیستم عامل",
                    ProfessorPresence= "به موقع شروع و به موقع کلاس رو تموم میکردند",
                    PresenceAbsence= "هر جلسه انجام میشد و حضور براشون مهم بود",
                    ProfessorBehavior= "خوب",
                    ClassResources= "جزوه، تصاویر",
                    ExamResources= "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                    Homeworks= "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                    ResourcesEnough= "بله",
                    TeachedEnough= "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                    Grading= "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                    Contact= "Nikakhtar@shariaty.ac.ir",
                    Semester= "بهمن 98",
                    Description= "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                    Score= 4
                },
                new Comment {
                    Id = 2,
                    Professor= "علیرضا موسی زاده",
                    Field= "نرم افزار",
                    Course= "کارگاه شبکه های کامپیوتری",
                    ProfessorPresence= "حضور استاد به موقع هست و ممکنه نهایتا یکی دو جلسه کنسل کنن",
                    PresenceAbsence= "معمولا صورت نمیگیره اما با پاسخ دهی شما حضورتون کاملا مشخص میشه چون استاد بین کلاس سوال مطرح میکنن که باید پاسخ بدین",
                    ProfessorBehavior= "خوبه هر چند بار که بخواین مباحث براتون توضیح داده میشه",
                    ClassResources= "پی دی اف های خود استاد",
                    ExamResources= "جزوه برداری شما، تمارین و پی دی اف ها",
                    Homeworks= "هر جلسه نخواهید داشت، اما با تموم شدن مبحث ممکنه تمرین زیادی بهتون داده بشه‌ ولی به قسمت عملی که برسین هر جلسه تمرین هست",
                    ResourcesEnough= "تقریبا کافی هست کمی نیاز به سرچ دارین و تلاش خودتون",
                    TeachedEnough= "کامل گفته شده",
                    Grading= "نمره دهی عالی بود",
                    Contact= "mousazadeh.alireza@gmail.com",
                    Semester= "بهمن 98",
                    Description= "اگر با استاد همراه باشید، هر جلسه جزوه برداری کنید، پیگیر تمارین باشید، کارتون راحت تر خواهد بود",
                    Score= 4
                },
                new Comment {
                    Id = 3,
                    Professor= "پژمان بورنگ",
                    Field= "نرم افزار",
                    Course= "بازاریابی مجازی",
                    ProfessorPresence= "کلاس معمولا سر موقع شروع میشه ولی زودتر تموم میشه",
                    PresenceAbsence= "بعضی جلسات انجام میشه، جلسات آخر تقریبا هر جلسه حضور غیاب داشتیم",
                    ProfessorBehavior= "خیلی خوب",
                    ClassResources= "جزوات و ارائه دانشجویان",
                    ExamResources= "جزوات و پی دی اف های استاد، ارائه دانشجویان",
                    Homeworks= "هر جلسه داشتیم تقریبا",
                    ResourcesEnough= "بله",
                    TeachedEnough= "بله",
                    Grading= "نمره ها کاملا دقیق بود نمره خودتون رو میگیرید قرار نیست چیزی بیشتر از میانگین نمره های قبلیتون، نمره پایانی و نمرات تمریناتون بگیرید",
                    Contact= "09223653952",
                    Semester= "بهمن 98",
                    Description= "حتما تمارین رو تحویل بدین، حتما برای امتحان بخونید چون سوالات مفهومی هست",
                    Score= 4
                },
            };
            _mockCommentService.Setup(service => service.GetComments()).Returns(expectedComments);

            var result = _controller.GetComments();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var comments = Assert.IsAssignableFrom<IEnumerable<Comment>>(okResult.Value);
            foreach (var comment in comments.Zip(expectedComments, (a, b) => new { Comment = a, ExpectedComment = b }))
            {
                Assert.Equal(comment.ExpectedComment.Id, comment.Comment.Id);
                Assert.Equal(comment.ExpectedComment.Professor, comment.Comment.Professor);
                Assert.Equal(comment.ExpectedComment.Field, comment.Comment.Field);
                Assert.Equal(comment.ExpectedComment.Course, comment.Comment.Course);
                Assert.Equal(comment.ExpectedComment.ProfessorPresence, comment.Comment.ProfessorPresence);
                Assert.Equal(comment.ExpectedComment.PresenceAbsence, comment.Comment.PresenceAbsence);
                Assert.Equal(comment.ExpectedComment.ProfessorBehavior, comment.Comment.ProfessorBehavior);
                Assert.Equal(comment.ExpectedComment.ClassResources, comment.Comment.ClassResources);
                Assert.Equal(comment.ExpectedComment.ExamResources, comment.Comment.ExamResources);
                Assert.Equal(comment.ExpectedComment.Homeworks, comment.Comment.Homeworks);
                Assert.Equal(comment.ExpectedComment.ResourcesEnough, comment.Comment.ResourcesEnough);
                Assert.Equal(comment.ExpectedComment.TeachedEnough, comment.Comment.TeachedEnough);
                Assert.Equal(comment.ExpectedComment.Grading, comment.Comment.Grading);
                Assert.Equal(comment.ExpectedComment.Contact, comment.Comment.Contact);
                Assert.Equal(comment.ExpectedComment.Semester, comment.Comment.Semester);
                Assert.Equal(comment.ExpectedComment.Description, comment.Comment.Description);
                Assert.Equal(comment.ExpectedComment.Score, comment.Comment.Score);
            }
        }

        [Fact]
        public void GetComment_WithValidId_ReturnsOkResult_WithMatchingComment()
        {
            var commentId = 1;
            var expectedComment = new Comment
            {
                Id = 1,
                Professor = "منیره نیک اختر",
                Field = "نرم افزار",
                Course = "آزمایشگاه سیستم عامل",
                ProfessorPresence = "به موقع شروع و به موقع کلاس رو تموم میکردند",
                PresenceAbsence = "هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior = "خوب",
                ClassResources = "جزوه، تصاویر",
                ExamResources = "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                Homeworks = "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                ResourcesEnough = "بله",
                TeachedEnough = "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                Grading = "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                Contact = "Nikakhtar@shariaty.ac.ir",
                Semester = "بهمن 98",
                Description = "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                Score = 4
            };
            _mockCommentService.Setup(service => service.GetComment(commentId)).Returns(expectedComment);

            var result = _controller.GetComment(commentId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var comment = Assert.IsAssignableFrom<Comment>(okResult.Value);
            Assert.Equal(expectedComment.Id, comment.Id);
            Assert.Equal(expectedComment.Professor, comment.Professor);
            Assert.Equal(expectedComment.Field, comment.Field);
            Assert.Equal(expectedComment.Course, comment.Course);
            Assert.Equal(expectedComment.ProfessorPresence, comment.ProfessorPresence);
            Assert.Equal(expectedComment.PresenceAbsence, comment.PresenceAbsence);
            Assert.Equal(expectedComment.ProfessorBehavior, comment.ProfessorBehavior);
            Assert.Equal(expectedComment.ClassResources, comment.ClassResources);
            Assert.Equal(expectedComment.ExamResources, comment.ExamResources);
            Assert.Equal(expectedComment.Homeworks, comment.Homeworks);
            Assert.Equal(expectedComment.ResourcesEnough, comment.ResourcesEnough);
            Assert.Equal(expectedComment.TeachedEnough, comment.TeachedEnough);
            Assert.Equal(expectedComment.Grading, comment.Grading);
            Assert.Equal(expectedComment.Contact, comment.Contact);
            Assert.Equal(expectedComment.Semester, comment.Semester);
            Assert.Equal(expectedComment.Description, comment.Description);
            Assert.Equal(expectedComment.Score, comment.Score);
        }

        [Fact]
        public void GetComment_WithInvalidId_ReturnsNotFoundResult()
        {
            var commentId = 4;
            _mockCommentService.Setup(service => service.GetComment(commentId)).Returns((Comment)null);

            var result = _controller.GetComment(commentId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void AddComment_ValidComment_ReturnsCreatedAtActionResult_WithNewComment()
        {
            var newComment = new Comment
            {
                Id = 1,
                Professor = "منیره نیک اختر",
                Field = "نرم افزار",
                Course = "آزمایشگاه سیستم عامل",
                ProfessorPresence = "به موقع شروع و به موقع کلاس رو تموم میکردند",
                PresenceAbsence = "هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior = "خوب",
                ClassResources = "جزوه، تصاویر",
                ExamResources = "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                Homeworks = "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                ResourcesEnough = "بله",
                TeachedEnough = "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                Grading = "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                Contact = "Nikakhtar@shariaty.ac.ir",
                Semester = "بهمن 98",
                Description = "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                Score = 4
            };
            _mockCommentService.Setup(service => service.AddComment(newComment)).Returns(new Comment
            {
                Id = 1,
                Professor = "منیره نیک اختر",
                Field = "نرم افزار",
                Course = "آزمایشگاه سیستم عامل",
                ProfessorPresence = "به موقع شروع و به موقع کلاس رو تموم میکردند",
                PresenceAbsence = "هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior = "خوب",
                ClassResources = "جزوه، تصاویر",
                ExamResources = "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                Homeworks = "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                ResourcesEnough = "بله",
                TeachedEnough = "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                Grading = "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                Contact = "Nikakhtar@shariaty.ac.ir",
                Semester = "بهمن 98",
                Description = "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                Score = 4
            });

            var result = _controller.AddComment(newComment);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var comment = Assert.IsAssignableFrom<Comment>(createdAtActionResult.Value);
            Assert.Equal(newComment.Id, comment.Id);
            Assert.Equal(newComment.Professor, comment.Professor);
            Assert.Equal(newComment.Field, comment.Field);
            Assert.Equal(newComment.Course, comment.Course);
            Assert.Equal(newComment.ProfessorPresence, comment.ProfessorPresence);
            Assert.Equal(newComment.PresenceAbsence, comment.PresenceAbsence);
            Assert.Equal(newComment.ProfessorBehavior, comment.ProfessorBehavior);
            Assert.Equal(newComment.ClassResources, comment.ClassResources);
            Assert.Equal(newComment.ExamResources, comment.ExamResources);
            Assert.Equal(newComment.Homeworks, comment.Homeworks);
            Assert.Equal(newComment.ResourcesEnough, comment.ResourcesEnough);
            Assert.Equal(newComment.TeachedEnough, comment.TeachedEnough);
            Assert.Equal(newComment.Grading, comment.Grading);
            Assert.Equal(newComment.Contact, comment.Contact);
            Assert.Equal(newComment.Semester, comment.Semester);
            Assert.Equal(newComment.Description, comment.Description);
            Assert.Equal(newComment.Score, comment.Score);
        }

        [Fact]
        public void UpdateComment_WithValidIdAndComment_ReturnsOkResult_WithUpdatedComment()
        {
            var commentId = 3;
            var updatedComment = new Comment
            {
                Id = 3,
                Professor = "منیره نیک اختر",
                Field = "نرم افزار",
                Course = "آزمایشگاه سیستم عامل",
                ProfessorPresence = "به موقع شروع و به موقع کلاس رو تموم میکردند",
                PresenceAbsence = "هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior = "خوب",
                ClassResources = "جزوه، تصاویر",
                ExamResources = "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                Homeworks = "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                ResourcesEnough = "بله",
                TeachedEnough = "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                Grading = "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                Contact = "Nikakhtar@shariaty.ac.ir",
                Semester = "بهمن 98",
                Description = "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                Score = 4
            };
            _mockCommentService.Setup(service => service.UpdateComment(commentId, updatedComment)).Returns(updatedComment);

            var result = _controller.UpdateComment(commentId, updatedComment);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var comment = Assert.IsAssignableFrom<Comment>(okResult.Value);
            Assert.Equal(updatedComment.Id, comment.Id);
            Assert.Equal(updatedComment.Professor, comment.Professor);
            Assert.Equal(updatedComment.Field, comment.Field);
            Assert.Equal(updatedComment.Course, comment.Course);
            Assert.Equal(updatedComment.ProfessorPresence, comment.ProfessorPresence);
            Assert.Equal(updatedComment.PresenceAbsence, comment.PresenceAbsence);
            Assert.Equal(updatedComment.ProfessorBehavior, comment.ProfessorBehavior);
            Assert.Equal(updatedComment.ClassResources, comment.ClassResources);
            Assert.Equal(updatedComment.ExamResources, comment.ExamResources);
            Assert.Equal(updatedComment.Homeworks, comment.Homeworks);
            Assert.Equal(updatedComment.ResourcesEnough, comment.ResourcesEnough);
            Assert.Equal(updatedComment.TeachedEnough, comment.TeachedEnough);
            Assert.Equal(updatedComment.Grading, comment.Grading);
            Assert.Equal(updatedComment.Contact, comment.Contact);
            Assert.Equal(updatedComment.Semester, comment.Semester);
            Assert.Equal(updatedComment.Description, comment.Description);
            Assert.Equal(updatedComment.Score, comment.Score);
        }

        [Fact]
        public void UpdateComment_WithInvalidId_ReturnsNotFoundResult()
        {
            var commentId = 4;
            var updatedComment = new Comment
            {
                Id = 3,
                Professor = "منیره نیک اختر",
                Field = "نرم افزار",
                Course = "آزمایشگاه سیستم عامل",
                ProfessorPresence = "به موقع شروع و به موقع کلاس رو تموم میکردند",
                PresenceAbsence = "هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior = "خوب",
                ClassResources = "جزوه، تصاویر",
                ExamResources = "تمام مباحثی که سرکلاس گفته میشد (جزوه، تصاویر، نکات مهمی که خارج از جزوه گفته میشد)",
                Homeworks = "با توجه به مبحث و نیاز کلاس تمرین میدادن برای هفته بعد و اینطوری نبود که هر جلسه تمرین داشته باشیم",
                ResourcesEnough = "بله",
                TeachedEnough = "اگر زمان کم باشه ممکنه سرفصل ها کامل نشن",
                Grading = "دقیقا نمره خود دانشجو لحاظ میشود بدون کوچکترین بالا یا پایینی",
                Contact = "Nikakhtar@shariaty.ac.ir",
                Semester = "بهمن 98",
                Description = "امتحانات زیادی در طول ترم میگیرن، امتحان پایان ترم هم به صورت تستی بود با تایم خیلی محدود و بدون امکان بازگشت به عقب",
                Score = 4
            };
            _mockCommentService.Setup(service => service.UpdateComment(commentId, updatedComment)).Returns((Comment)null);

            var result = _controller.UpdateComment(commentId, updatedComment);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}