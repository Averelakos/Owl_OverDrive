export interface UpdateCompanyDto{
    id: number,
    name: string
    description: string
    parentCompany: number
    foundedIn: Date
    countryId: number
    statusId: number
    changedDate: Date
    officialWebsite: string
    twitter: string
    newCompanyLogoId:string | null
    companyLogoId: number | null
}