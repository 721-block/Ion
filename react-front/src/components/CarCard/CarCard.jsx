import React from 'react';
import { Link } from 'react-router-dom';
import './CarCard.css';

const Card = ({ item }) => {
    return (
        <div className="cars-list">
            {item.map((Val) => {
                return (
                    <div className="car-card" id={`${Val.id}`}>
                        <Link to={`/announcement/${Val.id}`}>
                            <img src={`http://localhost:5000/${Val.pathToImages}1.png`} class="car-card-img" />
                            <div className="car-info">
                                <p className="mark">{Val.carName}</p>
                                <p className="price">{Val.pricePerUnit} руб</p>
                                <div className="avatar">
                                    <img src={`http://localhost:5000/images/${Val.authorId}/1.png`} height="80px" />
                                    <p>{Val.author.firstName} {Val.author.lastName}<br/>{Val.rating}*, {Val.reviewsCount} отзывы</p>
                                </div>
                            </div>
                        </Link>
                    </div>
                );
            })}
        </div>
    );
};

export default Card;