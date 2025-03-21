
import { Meeting } from "../Api/meetingTypes";

interface MeetingItemProps {
  meeting: Meeting;
}

export default function MeetingItem({ meeting }: MeetingItemProps) {
  return (
    <div className="border rounded-lg p-3 shadow-md flex justify-between items-center">
      <span className="font-semibold">{meeting.name}</span>
      <span className="text-gray-600">{new Date(meeting.date).toLocaleDateString()}</span>
    </div>
  );
}