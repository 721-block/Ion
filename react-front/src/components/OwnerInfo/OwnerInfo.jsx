import React from 'react';

const OwnerInfo = ({ owner }) => {
    return (
        <div className="user-info">
            <img src={owner.pathToPhoto || "../static/UserLogo.png"} height="75px" alt="User" />
            <div className="user-creds">
                <p>{`${owner.firstName} ${owner.lastName}`}</p>
                <p>{owner.phoneNumber}</p>
                <div className="rating">
                    <p className="score">{owner.rating || 'N/A'}</p>
                    <p className="reviews-count">{owner.reviewsCount || 0} оценок</p>
                </div>
            </div>
        </div>
    );
};

export default OwnerInfo; 