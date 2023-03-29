export interface IMansionApiResponse {
    id: string,
    statuscode: string,
    errormessages: string[],
    result: IMansionResult[]
}

export interface IMansionResult {
    id: string,
    name: string,
    details: string,
    rate: string,
    sqft: string,
    occupancy: string,
    base64Image: string,
    createdDate: Date,
    updatedDate: Date,
    isDeleted: boolean
}