﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Amigo
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }
        public String SobreNome { get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Status Status { get; set; }

    }

    public enum Status
    {
        NAO_ATIVO,
        ATIVO,
        EM_CONFIRMACAO_EMAIL
    }

}
