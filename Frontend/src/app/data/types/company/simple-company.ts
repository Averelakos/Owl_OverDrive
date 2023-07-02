export interface SimpleCompany{
    id:number
    name: string
    description: string
    parentCompanyId: number
    parentCompanyName: string
    foundedIn: Date
    countryId: number
    statusId: number
    changedDate: Date
    officialWebsite: string
    twitter: string
    imageTitle: string
    imageData: string
}