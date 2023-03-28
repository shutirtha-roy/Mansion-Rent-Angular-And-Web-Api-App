export interface IMansionApiResponse {
    id: string,
    statuscode: string,
    errormessages: string[],
    result: IMansionResult
}

export interface IMansionResult {
    id: string,
    name: string,
    details: string,
    rate: string,
    sqrt: string,
    occupancy: string,
    imageurl: string,
    amenity: string,
    createdDate: Date,
    updatedDate: Date,
    villaNumbers: IMansionResult[]
}