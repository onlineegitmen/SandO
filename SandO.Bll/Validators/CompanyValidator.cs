using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Entities.Enums;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class CompanyValidator
{
    private SandOContext context;
    private Company Company { get; }

    public CompanyValidator(Company company)
    {
        Company = company;
        context = new SandOContext(GlobalVariables.DbContextOptions);
    }
    public ProgressResult Validate()
    {
        ProgressResult result = new ProgressResult(true);

        if (Company.Code.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Şirket kodu boş bırakılamaz.";
        }

        if (Company.Code.IsMoreThanMaxLength(10))
        {
            result.Result = false;
            result.Message = "Şirket kodu en fazla 10 karakter olabilir.";
        }

        if (CompanyCodeExists())
        {
            result.Result = false;
            result.Message = "Bu şirket kodu zaten kullanılmaktadır.";
        }

        if (Company.Name.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Şirket adı boş bırakılamaz.";
        }

        if (Company.Name.IsMoreThanMaxLength(100))
        {
            result.Result = false;
            result.Message = "Şirket adı en fazla 100 karakter olabilir.";
        }

        if (CompanyNameExists())
        {
            result.Result = false;
            result.Message = "Bu şirket adı zaten kullanılmaktadır.";
        }

        if (Company.TaxNumber.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Vergi numarası boş bırakılamaz.";
        }

        if (Company.TaxNumber.IsMoreThanMaxLength(20))
        {
            result.Result = false;
            result.Message = "Vergi numarası en fazla 20 karakter olabilir.";
        }

        if (CompanyTaxNumberExists())
        {
            result.Result = false;
            result.Message = "Bu vergi numarası zaten kullanılmaktadır.";
        }

        if (Company.TaxOffice.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Vergi dairesi boş bırakılamaz.";
        }

        if (Company.TaxOffice.IsMoreThanMaxLength(100))
        {
            result.Result = false;
            result.Message = "Vergi dairesi en fazla 100 karakter olabilir.";
        }

        if (Company.TradeRegistryNumber.IsNullOrEmptyOrWhiteSpace())
        {
            result.Result = false;
            result.Message = "Ticaret sicil numarası boş bırakılamaz.";
        }

        if (Company.TradeRegistryNumber.IsMoreThanMaxLength(20))
        {
            result.Result = false;
            result.Message = "Ticaret sicil numarası en fazla 20 karakter olabilir.";
        }

        if (CompanyTradeRegistryNumberExists())
        {
            result.Result = false;
            result.Message = "Bu ticaret sicil numarası zaten kullanılmaktadır.";
        }

        context.Dispose();

        return result;
    }

    private bool CompanyTradeRegistryNumberExists()
    {
        return context.Companies.Any(x => x.TradeRegistryNumber == Company.TradeRegistryNumber && x.Id != Company.Id && x.RecordState == RecordState.Active);
    }

    private bool CompanyTaxNumberExists()
    {
        return context.Companies.Any(x => x.TaxNumber == Company.TaxNumber && x.Id != Company.Id && x.RecordState == RecordState.Active);
    }

    private bool CompanyNameExists()
    {
        return context.Companies.Any(x => x.Name == Company.Name && x.Id != Company.Id && x.RecordState == RecordState.Active);
    }

    private bool CompanyCodeExists()
    {
        return context.Companies.Any(x => x.Code == Company.Code && x.Id != Company.Id && x.RecordState == RecordState.Active);
    }
}