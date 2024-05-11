export interface Message {
    id: string;
    senderUserId: string;
    content: string;
    sentAt: Date;
    recipientUserId?: string;
    sender?: any;
    recipient?: any;
}