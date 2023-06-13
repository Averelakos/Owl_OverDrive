export interface CreateCompanyDto{
    name: string
    description: string
    parentCompany: number
    foundedIn: Date
    countryId: number
    statusId: number
    changedDate: Date
    officialWebsite: string
    twitter: string
}