import { useEffect, useState } from "react";
import MeetingItem from "./MeetingItem";
import { Meeting } from "../Api/meetingTypes";
import { fetchMeetings } from "../Api/meetingService";

export default function MeetingList() {
    const [meetings, setMeetings] = useState<Meeting[]>([]);

    useEffect(() => {
        const getMeetings = async () => {
            const data = await fetchMeetings();
            setMeetings(data);
        };
        getMeetings();
    }, []);

    return (
        <div className="p-6 max-w-3xl mx-auto">
            <h2 className="text-2xl font-bold text-center mb-4">רשימת ישיבות</h2>
            <div className="space-y-2">
                {meetings.length > 0 ? (
                    meetings.map((meeting) => <MeetingItem key={meeting.id} meeting={meeting} />)
                ) : (
                    <p className="text-gray-500">אין ישיבות כרגע.</p>
                )}

            </div>
        </div>
    );
}