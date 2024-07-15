﻿using System;
using System.Collections.Generic;
using System.Text;
using Rocoso;

namespace Rocoso.UnitTest.PersonObjects

{
    public abstract class PersonEditBase<T> : EditBase<T>, IPersonBase
        where T : PersonEditBase<T>
    {

        public PersonEditBase(IEditBaseServices<T> services) : base(services)
        {
        }

        private IRegisteredProperty<Guid> IdProperty => GetRegisteredProperty<Guid>(nameof(Id));
        public Guid Id { get { return Getter<Guid>(); } }

        public string FirstName { get { return Getter<string>(); } set { Setter(value); } }

        public string LastName { get { return Getter<string>(); } set { Setter(value); } }

        public string ShortName { get { return Getter<string>(); } set { Setter(value); } }

        public string Title { get { return Getter<string>(); } set { Setter(value); } }

        public string FullName { get { return Getter<string>(); } set { Setter(value); } }

        public uint? Age { get => Getter<uint>(); set => Setter(value); }
        public void FillFromDto(PersonDto dto)
        {
            LoadProperty(IdProperty, dto.PersonId);

            // These will not mark IsModified to true
            // as long as within ObjectPortal operation
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Title = dto.Title;
        }
    }
}
