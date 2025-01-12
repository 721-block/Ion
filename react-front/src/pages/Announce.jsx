import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../components/Header/Header';
import AnnouncementDetails from '../components/AnnouncementDetails/AnnouncementDetails';
import './Announce.css'

const Announce = () => {
    const { announcementId } = useParams();
    const [announcement, setAnnouncement] = useState(null);

    useEffect(() => {
        fetchAnnouncement();
    }, [announcementId]);

    const fetchAnnouncement = async () => {
        try {
            const response = await fetch(`http://721block.ru:5000/api/Announcement/${announcementId}`);
            let data = await response.json();
            const userResponse = await fetch(`http://721block.ru:5000/api/User/${data["authorId"]}`);
            let authorInfo = await userResponse.json();
            data["author"] = authorInfo;
            const reviews = await fetch(`http://721block.ru:5000/api/Review/GetByAnnouncementId/${announcementId}`);
            let reviewsList = await reviews.json();
            data["reviews"] = reviewsList;
            data["images"] = [`${data.pathToImages}1.png`, `${data.pathToImages}2.png`, `${data.pathToImages}3.png`];
            setAnnouncement(data);
        } catch (error) {
            console.error('Error fetching announcement:', error);
        }
    };

    return (
        <div>
            <Header />
            <div className="main-container announce">
                {announcement ? (
                    <AnnouncementDetails announcement={announcement} />
                ) : (
                    <p>Loading...</p>
                )}
            </div>
        </div>
    );
};

export default Announce; 