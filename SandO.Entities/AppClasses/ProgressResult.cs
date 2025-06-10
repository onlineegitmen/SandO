using System.Text;

namespace SandO.Entities.AppClasses;

public class ProgressResult
{
    public string ErrorMessage => "İşlem sırasında bir hata oluştu.";
    public string SuccessMessage => "İşlem başarıyla tamamlandı.";
    public ProgressResult(bool result)
    {
        Result = result;
    }

    public ProgressResult(bool result, string message)
    {
        Result = result;
        AddMessage(message);
    }

    public List<string> Messages
    {
        get => messages ??= new List<string>();
        set => messages = value;
    }

    public void AddMessage(string message)
    {
        messages ??= new List<string>();

        messages.Add(message);
    }

    public void AddMessages(List<string> messages)
    {
        this.messages ??= new List<string>();
        this.messages.AddRange(messages);
    }

    public string Message
    {
        get
        {
            if (messages == null || messages.Count == 0)
            {
                return Result ? SuccessMessage : ErrorMessage;
            }

            StringBuilder sb = new();
            foreach (var message in messages)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }
        set
        {
            messages ??= new List<string>();
            messages.Add(value);
        }
    }
    public bool Result { get; set; }
    private List<string>? messages;
    public object ResultKey { get; set; }
}