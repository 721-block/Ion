import React from 'react';
import { Link } from 'react-router-dom';

const CarsList = ({ announcements }) => {
    return (
        <div className="cars-list">
            {announcements.map(announcement => (
                <div key={announcement.id} className="car-card">
                    <Link to={`/announcement/${announcement.id}`}>
                        <img 
                            src={announcement.pathToImages || "../static/Car.png"} 
                            className="car-card-img" 
                            alt={announcement.carName}
                        />
                        <div className="car-info">
                            <p className="mark">{announcement.carName}</p>
                            <p className="price">{announcement.pricePerUnit} руб/день</p>
                            <div className="avatar">
                                <img src="../static/UserLogo.png" height="80" alt="User" />
                                <p>{`${announcement.authorName} - ${announcement.rating}`}</p>
                            </div>
                        </div>
                    </Link>
                </div>
            ))}
        </div>
    );
};

export default CarsList; 