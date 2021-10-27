using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSEPABlogPost.Entities
{
    public class Comment
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CommId { get; set; }
        [Required(ErrorMessage = "Comments is Required")]
        [Display(Name = "Comment on Post")]
        public string CommentMsg { get; set; }
        [Display(Name = "Commented Date")]
        public DateTime CommentedDate { get; set; } = DateTime.Now;

        //EF relationships should pick this relationship between Blog and Comments tables:
        [Display(Name = "Post ID")]
        public virtual string PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual BlogPost BlogPosts { get; set; }
    }
}
