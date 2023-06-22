namespace shariaty_course.Models
{
    public class CommentService : ICommentService
    {
        private readonly List<Comment> _comments = new List<Comment>
        {
            new Comment {
                Id = 1,
                Professor = "بهناز آقابالایی",
                Field="نرم افزار",
                Course="برنامه سازی پیشرفته",
                ProfessorPresence="به موقع حاضر میشدن و تقریبا تا دقایق آخر کلاس تشکیل می‌شد",
                PresenceAbsence="هر جلسه آخر کلاس انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior="عالی هستند",
                ClassResources="پاور پوینت استاد و جزوه",
                ExamResources="پاور پوینت استاد، جزوه، ارائه های منتخب بچه ها",
                Homeworks="ارائه به صورت گروهی",
                ResourcesEnough="بله؛ علاوه بر این موارد دانشجو باید برای پاسخ دهی به سوالات خلاقیت داشته باشد چون سوالات امتحان کاربردی است",
                TeachedEnough="بله کامل تدریس شد",
                Grading="عالی",
                Contact="b.aghabalaee@yahoo.com",
                Semester="بهمن 98",
                Description="کلاس جو خیلی خوبی داشت و علاوه به سرفصل های درسی نکات مفیدی درباره آینده این رشته سرکلاس گفته میشد. شخصیت ایشون هم به گونه ای هست که دانشجو رو میفهمن و بهش گوش میدن",
                Score=5
            },
            new Comment {
                Id = 2,
                Professor = "عفیفه کریمی مصدق",
                Field="نرم افزار",
                Course="برنامه سازی پیشرفته",
                ProfessorPresence="به موقع حاضر میشدن و تقریبا تا یک ساعت کمتر از تایم استاندارد کلاس درس میدادن",
                PresenceAbsence="هر جلسه انجام میشد و حضور براشون مهم بود",
                ProfessorBehavior="خوب بود و پاسخگوی سوالات دانشجویان بودند",
                ClassResources="پاور پوینت",
                ExamResources="پاور پوینت، جزوه، تمرین های داده شده در طول ترم",
                Homeworks="هر هفته برای جلسه بعد چند سوال میدادند که باید از کد و اجرا براشون عکس میفرستادیم",
                ResourcesEnough="تقریبا بله؛ علاوه بر این چند سوال در امتحان پایان ترم بالاتر از سطح تدریس بود و برای حل شان نیاز به مهارت بالا بود",
                TeachedEnough="چند سرفصل به علت کمبود زمان تدریس نشد و به یک سری از مباحث به صورت کامل پرداخته نشد",
                Grading="خوب",
                Contact="rkmosadegh@gmail.com",
                Semester="بهمن 98",
                Description=" - ",
                Score=3
            },
            new Comment {
                Id = 3,
                Professor = "فاطمه فلاح",
                Field="نرم افزار",
                Course="طراحی وب",
                ProfessorPresence="معمولا ده دقیقه با تاخیر و میانگین ۲۰ دقیقه کلاس دیر تر از موعد مقرر به اتمام میرسه",
                PresenceAbsence="هر جلسه انجام میشه و بین جلسه حضور دانشجویان به یه نحوی مثل پاسخ دادن به سوال استاد یا share کردن سیستم دانشجو، چک میشه",
                ProfessorBehavior="برخورد با دانشجوها خوبه و به شما کاملا وقت این داده میشه که هم کد بزنید هم جزوه بنویسید، سرعت استاد عالی هست برای اینکارا",
                ClassResources="سایت های مربوط به درس انتخابی (مثلا برای طراحی وب، قسمت وب دیزاین w3schools)",
                ExamResources="آموزش خود استاد، جزوه برداری های خودتون و همون سایت بالا",
                Homeworks="هر جلسه از موارد آموزش داده تمرین خواهید داشت، خیلی مهم هستن",
                ResourcesEnough="جزوه کاملا کافی هست",
                TeachedEnough="ممکنه بخش کوچیکی بمونه، که اگر تدریس نشه برای امتحان و پروژه نیاز نیست اون بخش",
                Grading="کاملا منطقی، خوب",
                Contact="fh.fallah90@gmail.com",
                Semester="بهمن 98",
                Description="اگر با استاد همراه باشید هم موارد خوبی یاد میگیرید و نهایتا نمره خوبی هم خواهید گرفت",
                Score=4
            },
        };

        public IEnumerable<Comment> GetComments()
        {
            return _comments;
        }

        public Comment GetComment(int id)
        {
            var comment = _comments.FirstOrDefault(comment => comment.Id == id);
            if (comment == null)
            {
                throw new ArgumentException($"Comment with ID {id} not found.");
            }
            return comment;
        }

        public Comment AddComment(Comment comment)
        {
            comment.Id = _comments.Select(comment => comment.Id).DefaultIfEmpty(0).Max() + 1;
            _comments.Add(comment);
            return comment;
        }

        public Comment UpdateComment(int id, Comment comment)
        {
            var existingComment = _comments.FirstOrDefault(c => c.Id == id);
            if (existingComment != null)
            {
                existingComment.Professor = comment.Professor;
                existingComment.Field = comment.Field;
                existingComment.Course = comment.Course;
                existingComment.ProfessorPresence = comment.ProfessorPresence;
                existingComment.PresenceAbsence = comment.PresenceAbsence;
                existingComment.ProfessorBehavior = comment.ProfessorBehavior;
                existingComment.ClassResources = comment.ClassResources;
                existingComment.ExamResources = comment.ExamResources;
                existingComment.Homeworks = comment.Homeworks;
                existingComment.ResourcesEnough = comment.ResourcesEnough;
                existingComment.TeachedEnough = comment.TeachedEnough;
                existingComment.Grading = comment.Grading;
                existingComment.Contact = comment.Contact;
                existingComment.Semester = comment.Semester;
                existingComment.Description = comment.Description;
                existingComment.Score = comment.Score;

            }
            return existingComment;
        }
    }
}
