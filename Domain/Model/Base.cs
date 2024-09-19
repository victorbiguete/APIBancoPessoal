using System.ComponentModel.DataAnnotations;

namespace APIBanco.Domain.Model
{
    public abstract class Base
    {
        [Key]
        public long Id { get; init; }

        internal List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
