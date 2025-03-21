// import { useState } from "react";
// import MeetingList from "../Meeting/MeetingList";
// import AddMeetingForm from "../Meeting/AddMeetingForm";
// import { Meeting } from "../Api/meetingService";

// export default function MeetingsPage() {
//   const [meetings, setMeetings] = useState<Meeting[]>([]);

//   const handleMeetingAdded = (newMeeting: Meeting) => {
//     setMeetings((prevMeetings) => [...prevMeetings, newMeeting]);
//   };

//   return (
//     <div className="p-6 max-w-3xl mx-auto">
//       <h1 className="text-3xl font-bold text-center mb-6">MeetSummarizer</h1>
//       <MeetingList />
//       <div className="mt-6">
//         <AddMeetingForm onMeetingAdded={handleMeetingAdded} />
//       </div>
//     </div>
//   );
// }




import { useState } from "react";
import { Meeting } from "../Api/meetingTypes";
import AddMeetingForm from "../Meeting/AddMeetingForm";
// import AddMeetingForm from "../components/AddMeetingForm";
// import { Meeting } from "../api/meetingTypes";

const MeetingsPage = () => {
    const [meetings, setMeetings] = useState<Meeting[]>([]);

    const handleMeetingAdded = (newMeeting: Meeting) => {
        setMeetings((prevMeetings) => [...prevMeetings, newMeeting]);
    };

    return (
        <div>
            <h2 className="text-2xl font-bold mb-4">ניהול ישיבות</h2>
            <AddMeetingForm onMeetingAdded={handleMeetingAdded} />
            <ul className="mt-4">
                {meetings.map((meeting) => (
                    <li key={meeting.id} className="border p-2 rounded-md mb-2">
                        <strong>{meeting.name}</strong> - {new Date(meeting.date).toLocaleString()}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default MeetingsPage;
