using Volo.Abp;

namespace Koa.Platform.Ddd.Application.Constracts.Dtos
{
    public class FilterDescriptor
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

        public FilterDescriptor(string field, string @operator, string value)
        {
            Check.NotNullOrEmpty(field, nameof(field));
            Check.NotNullOrEmpty(@operator, nameof(@operator));
            Check.NotNullOrEmpty(value, nameof(value));

            Field = field;
            Operator = @operator;
            Value = value;
        }


    }
}
