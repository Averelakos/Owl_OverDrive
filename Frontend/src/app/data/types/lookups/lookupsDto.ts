import { CompanyStatusLookupDto } from "./company-status-lookup-dto";
import { CountryCodeLookupDto } from "./country-code-lookup-dto";
import { GameStatusLookupDto } from "./game-statuses-lookup-dto";
import { RegionLookupDto } from "./region-lookup-dto";

export interface LookupsDto{
    companyStatus: CompanyStatusLookupDto[]
    countryCode: CountryCodeLookupDto[]
    regions: RegionLookupDto[]
    gameStatuses: GameStatusLookupDto[]
}