using AutoMapper;

namespace PM.ServiceSoap.Base
{
    public class Base
    {
        private IMapper _mapper;

        public Base()
        {
            if (_mapper == null)
            {
                _mapper = ServiceSoap.Mapper.AutoMapper.GetInstance();
            }
        }
        protected IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
    }
}