import React from 'react';
import { Link } from 'react-router-dom';
//import './ReviewsList.css'

const ReviewsList = ({ reviews, ownerId }) => {
    return (
        <div className="reviews-list">
            {reviews.map((review, index) => (review.userId !== ownerId) && (review.userId > ownerId) && (index < ownerId + 2) && (
                <div key={index} className="review">
                    <div className="reviewer">
                        <Link to={`/user/${review.userId}`} className="avatar">
                            <img src={`http://localhost:5000/images/${review.userId}/1.png`} height="80" width="80" alt="Reviewer" />
                            <p>{review.userFirstName} {review.userLastName} - {review.rating}</p>
                        </Link>
                    </div>
                    <div className="review-box-2">
                        <p>{review.content}</p>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default ReviewsList; 