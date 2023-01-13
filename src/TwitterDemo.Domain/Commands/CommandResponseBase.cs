using FluentValidation.Results;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace TwitterDemo.Domain.Commands
{
    public class CommandResponseBase
    {
        private readonly IList<ErrorItem> _messages = new List<ErrorItem>();

        [JsonIgnore]
        public ICollection<ErrorItem> Errors { get; }
        [JsonIgnore]
        public bool IsValid => !_messages.Any();

        public CommandResponseBase() => Errors = new ReadOnlyCollection<ErrorItem>(_messages);

        public CommandResponseBase AddError(string message)
        {
            AddError(string.Empty, message);
            return this;
        }
        public CommandResponseBase AddError(string key, string message)
        {
            _messages.Add(new ErrorItem(key, message));
            return this;
        }
        public CommandResponseBase AddError(List<ValidationFailure> errors)
        {
            foreach (var item in errors)
            {
                this.AddError(item.PropertyName, item.ErrorMessage);
            }
            return this;
        }

        public class ErrorItem
        {
            public ErrorItem(string propertyName, string message)
            {
                PropertyName = propertyName;
                Message = message;
            }

            public string PropertyName { get; set; }
            public string Message { get; set; }
        }
    }
}
