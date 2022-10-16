import { MessageType } from "./messageTypeEnum";

export class ApiMessage{
    public text: string | null = "";
    public type: MessageType | undefined;
}