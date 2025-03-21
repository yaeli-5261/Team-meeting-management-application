export interface MeetingPostDTO {
    name: string;
    date: string; // תאריך בפורמט ISO 8601
    userIds: number[];
}

export interface Meeting {
    id: number;
    name: string;
    date: string;
    userIds: number[];
}
