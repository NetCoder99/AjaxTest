namespace AjaxTest.Models
{
    [FluentValidation.Attributes.Validator(typeof(AjaxTestValid))]
    public class AjaxTestModel
    {
        public bool OptIn { get; set; }
        public string Name { get; set; }
    }
}