

export interface MeasureResponse {
    "sId": string,
    "ts": MeasureResponseDate,
    "preciptation": number, 
    "temperature": number,
    "pressure": number,
    "label": string,
    "position" : MeasureResponsePosition
}

export interface MeasureResponseDate {
    "date": Date
}

export interface MeasureResponsePosition {
    "lat": number,
    "lon": number
}

export interface MeasureRequest {
    "InitialDate": string,
    "FinalDate": string
}