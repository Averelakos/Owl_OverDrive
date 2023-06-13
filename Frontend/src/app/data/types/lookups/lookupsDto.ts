import { CompanyStatusLookupDto } from "./company-status-lookup-dto";
import { CountryCodeLookupDto } from "./country-code-lookup-dto";

export interface LookupsDto{
    companyStatus: CompanyStatusLookupDto[]
    countryCode: CountryCodeLookupDto[]
}