import { ApiMessage } from "./apiMessage";

export class ApiResponse<T>{
    public success: boolean | undefined;
    public message: ApiMessage | undefined;
    public messages: Array<ApiMessage> | undefined;
    public statusCode: number | undefined;
    public data: T | undefined;
}


