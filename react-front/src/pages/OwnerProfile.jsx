import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../components/Header/Header';
import UserProfile from '../components/UserProfile/UserProfile';
import './OwnerProfile.css'

const OwnerProfile = () => {
    const [cars, setCars] = useState([]);
    const [reviews, setReviews] = useState([]);
    const [userData, setData] = useState([]);
    const { userId } = useParams();

    useEffect(() => {
        fetchProfile();
    }, [userId]);

    const fetchProfile = async () => {
        const response = await fetch(`http://721block.ru:5000/api/User/${userId}`);
        let data = await response.json();
        const carsResponse = await fetch(`http://721block.ru:5000/api/Announcement/GetAnnouncementsByAuthorId/${userId}`);
        let carss = await carsResponse.json();
        let rl = [];
        for(var k in carss){
            const userResponse = await fetch(`http://721block.ru:5000/api/User/${carss[k].authorId}`);
            let authorInfo = await userResponse.json();
            carss[k]["author"] = authorInfo;
            const r = await fetch(`http://721block.ru:5000/api/Review/GetByAnnouncementId/${userId}`)
            if(rl.length > 0){
                continue;
            }
            let reviewsL = await r.json();
            for(var ii in reviewsL){
                rl.push(reviewsL[ii]);
                console.log(rl, k);
            }
        }
        
        setReviews(rl);
        console.log(reviews.length);
        setCars(carss);
        setData(data);
    };

    return (
        <div>
            <Header showAdd=''/>
            <div className="main-container profile">
                <UserProfile data={userData} reviews={reviews} cars={cars} ownerId={userId}/>
            </div>
        </div>
    );
};

export default OwnerProfile; 