export interface SimpleCompany{
    name: string
    description: string
    parentCompany: number
    parentCompanyName: string
    foundedIn: Date
    countryId: number
    statusId: number
    changedDate: Date
    officialWebsite: string
    twitter: string
    imageTitle: string
    imageData: any
    image: Blob
}