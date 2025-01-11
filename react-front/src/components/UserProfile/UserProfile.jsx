import React from 'react';
import { Link } from 'react-router-dom';
import Card from '../CarCard/CarCard';
import ReviewsList from '../ReviewsList/ReviewsList';
import './UserProfile.css';

const UserProfile = ({ data, reviews, cars, ownerId }) => {
    return (
        <>
        <div className="top-container user-profile">
            <div className="user-info">
                <img src={`http://localhost:5000/${data.pathToPhoto}`} height="75px" width="75px" className="avatar"/>
                <div className="user-creds">
                    <p>{data.firstName} {data.lastName}</p>
                    <p>{data.phoneNumber}</p>
                    <div className="rating">
                        <p className="score">4,3</p>
                        <p className="reviews-count">12 оценок</p>
                    </div>
                </div>
            </div>
            <div className="orders-history">
                <p>Актуальные объявления</p>
                    <Card item={cars}/>
            </div>
        </div>
        <div className="user-reviews user-profile">
            <ReviewsList reviews={reviews} ownerId={ownerId}/>
        </div>
        </>
    );
};

export default UserProfile; 