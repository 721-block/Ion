import React from 'react';
import { Link } from 'react-router-dom';
import './AnnouncementDetails.css';
import { YMaps, Map, ObjectManager, Placemark } from '@pbe/react-yandex-maps';

const AnnouncementDetails = ({ announcement }) => {
    return (
        <div className="announcement-details">
            <div className="owner-info">
                <div className="owner-data">
                    <Link to={`/user/${announcement.authorId}`} className="avatar">
                        <img src={`http://721block.ru:5000/images/${announcement.authorId}/1.png`} alt="Фото профиля" width="100" />
                    </Link>
                    <div className="owner-name">
                        <p>{announcement.author.firstName} {announcement.author.lastName}</p>
                        <p>{announcement.rating}* - {announcement.reviewsCount} отзыва</p>
                    </div>
                </div>
            </div>
            <div className="car-info">
                <div className="car-images">
                    {announcement.images.map((image) => (
                        <img src={`http://721block.ru:5000/${image}`} alt="CarImage" />
                    ))}
                </div>
                <div className="car-data">
                    <h3>{announcement.carName}</h3>
                    <div className="car-parameter">
                        <p>Тип кузова</p>
                        <p>{announcement.carBodyType}</p>
                    </div>
                    <div className="car-parameter">
                        <p>Тип КПП</p>
                        <p>{announcement.carGearboxType}</p>
                    </div>
                    <div className="car-parameter">
                        <p>Цена</p>
                        <p>{announcement.pricePerUnit} руб/день</p>
                    </div>
                    <YMaps>
                        <div className="map-container details">
                            <Map className="map-map details" defaultState={{ center: [announcement.carLocation.x, announcement.carLocation.y], zoom: 13.71 }}>
                                <ObjectManager
                                    options={{
                                        clusterize: true,
                                        gridSize: 32,
                                    }}
                                    objects={{
                                        openBalloonOnClick: true,
                                        preset: "islands#greenDotIcon",
                                    }}
                                    clusters={{
                                        preset: "islands#redClusterIcons",
                                    }}
                                    modules={[
                                        "objectManager.addon.objectsBalloon",
                                        "objectManager.addon.objectsHint",
                                    ]}
                                />
                                        <Placemark geometry={[announcement.carLocation.x, announcement.carLocation.y]} properties={{
                                            balloonContent: () => '',
                                            iconCaption: `${announcement.carName} - ${announcement.pricePerUnit} руб`

                                        }} options={{
                                            preset: 'islands#greenDotIconWithCaption',
                                            iconColor: '#aeca3b',
                                            controls: []
                                        }} />

                            </Map>
                        </div>
                    </YMaps>
                </div>
            </div>
            <div className="car-info-additional">
                <div className="announce-description">
                    <h3>Информация об авто</h3>
                    <p>{announcement.description}</p>
                </div>
            </div>
            <div className="user-reviews">
                <p>{announcement.rating}* - на основании {announcement.reviewsCount} оценок</p>
                <div className="reviews-list">
                    {announcement.reviews.map((review, index) => (
                        <div key={index} className="review">
                            <div className="reviewer">
                                <Link to={`/user/${review.userId}`} className="avatar">
                                    <img src={`http://721block.ru:5000/images/${review.userId}/1.png`} height="80" width="80" alt="Reviewer" />
                                    <p>{review.userFirstName} {review.userLastName} - {review.rating}</p>
                                </Link>
                            </div>
                            <div className="review-box">
                                <p>{review.content}</p>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default AnnouncementDetails; 