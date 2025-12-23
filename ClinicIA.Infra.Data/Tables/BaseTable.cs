using System;

namespace ClinicIA.Infra.Data.Tables
{
    public abstract class BaseTable
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
