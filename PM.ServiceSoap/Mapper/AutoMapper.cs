using AutoMapper;
using PM.Domain.Entities;
using PM.ServiceSoap.Models;

namespace PM.ServiceSoap.Mapper
{
    public static class AutoMapper
    {
        public static IMapper GetInstance()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Carro, CarroModel>();
                cfg.CreateMap<CarroModel, Carro>();

                cfg.CreateMap<Patio, PatioModel>();
                cfg.CreateMap<PatioModel, Patio>();

                cfg.CreateMap<Diagnostico, DiagnosticoModel>();
                cfg.CreateMap<DiagnosticoModel, Diagnostico>();
                
                cfg.CreateMap<Frota, FrotaModel>();
                cfg.CreateMap<FrotaModel, Frota>();

                cfg.CreateMap<Linha, LinhaModel>();
                cfg.CreateMap<LinhaModel, Linha>();
                                
                cfg.CreateMap<Material, MateriaisModel>();
                cfg.CreateMap<MateriaisModel, Material>();
                
                cfg.CreateMap<Sistema, SistemaModel>();
                cfg.CreateMap<SistemaModel, Sistema>();

                cfg.CreateMap<Trem, TremModel>();
                cfg.CreateMap<TremModel, Trem>();

                cfg.CreateMap<Zona, ZonaModel>();
                cfg.CreateMap<ZonaModel, Zona>();

            });

            return config.CreateMapper();
        }
    }
}