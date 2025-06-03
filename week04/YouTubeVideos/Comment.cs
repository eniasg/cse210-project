using System;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    public string GetCommenterName() => _commenterName;
    public string GetCommentText() => _commentText;
}