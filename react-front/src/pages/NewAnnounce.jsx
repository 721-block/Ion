import React, { useState } from 'react';
import Header from '../components/Header/Header';
import './NewAnnounce.css';
import { YMaps, Map, ObjectManager, Placemark } from '@pbe/react-yandex-maps';
import { useNavigate } from 'react-router-dom';

const AddAnnounce = () => {
    
  let navigate = useNavigate();
    const [myMap, setMap] = useState({ center: [56.832299, 60.613234], zoom: 13 });
    const [coordinate, setCoordinate] = useState([56.832299, 60.613234]);
    const [formData, setFormData] = useState({
        carName: '',
        carModel: '',
        bodyType: '',
        pricePerUnit: '',
        description: '',
        gearboxType: '',
        files: []
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
        console.log(coordinate);
    };

    const handleFileChange = (e) => {
        setFormData({
            ...formData,
            files: e.target.files
        });
        console.log(formData);
    };

    const handleSubmit = async (e) => {
        
        e.preventDefault();
        console.log(formData);

        formData["authorId"] = 1;
        formData["availableDays"] = 2;
        formData["isActive"] = true;
        console.log(coordinate);
        
        const formDataToSend = new FormData();
        formDataToSend.append('carLocation.x', coordinate[0].toString().replace(/[.]/, ","));
        formDataToSend.append('carLocation.y', coordinate[1].toString().replace(/[.]/, ","));
        for (const key in formData) {
            if (key === 'files') {
                Array.from(formData.files).forEach(file => {
                    formDataToSend.append('files', file);
                });
            } else {
                formDataToSend.append(key, formData[key]);
            }
        }

        console.log(formDataToSend);
        console.log(formData);

        const carAdd = await fetch('http://721block.ru:5000/api/Car', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
              },
            body: JSON.stringify({
                "userId": 1,
                "gearboxType": formData.gearboxType,
                "name": formData.carName,
                "bodyType": formData.bodyType,
                "isAnnounced": true
            })
        })
        let responses = await carAdd.json();
        console.log(responses);
        formDataToSend.append('carId', responses);

        try {
            const response = await fetch('http://721block.ru:5000/api/Announcement', {
                method: 'POST',
                body: formDataToSend
            });
            if (!response.ok) throw new Error('Failed to create announcement');
            navigate(`/announcement/${await response.json()}`, { replace: true });
        } catch (error) {
            console.error('Error creating announcement:', error);
        }
    };

    return (
        <div>
            <Header showAdd=''/>
            <div className="main-container add-desc">
                <div className="car-info add-desc">
                    <div className="car-images add-desc">
                        <YMaps>
                            <div className="map-container add-desc">
                                <Map className="map-map add-desc" defaultState={{ center: [56.832299, 60.613234], zoom: 13 }} onClick={(e) => {
                                    const coords = e.get("coords");
                                    setCoordinate(coords);
                                }}>
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

                                </Map>
                            </div>
                        </YMaps>
                        <input type="file" name="files" multiple onChange={handleFileChange} />
                    </div>
                    <form className="car-data add-desc" onSubmit={handleSubmit}>
                        <h3>Параметры авто</h3>
                        <div className="car-parameter add-desc">
                            <p>Марка</p>
                            <input type="text" name="carName" value={formData.carMake} onChange={handleChange} required />
                        </div>
                        <div className="car-parameter add-desc">
                            <p>Тип кузова</p>
                            <select
                                name="bodyType"
                                value={formData.bodyType}
                                onChange={handleChange}
                            >
                                <option value="">Тип кузова</option>
                                <option value="Sedan">Седан</option>
                                <option value="Hatchback">Хэтчбек</option>
                                <option value="Liftback">Лифтбек</option>
                                <option value="Universal">Универсал</option>
                                <option value="Pickup">Пикап</option>
                                <option value="Minivan">Минивэн</option>
                                <option value="Crossover">Кроссовер</option>
                                <option value="Offroad">Внедорожник</option>
                                <option value="Coupe">Купе</option>
                                <option value="Roadster">Родстер</option>
                                <option value="Cabriolet">Кабриолет</option>
                            </select>
                        </div>
                        <div className='car-parameter add-desc'>
                            <p>Тип КПП</p>
                            <select 
                                name="gearboxType"
                                value={formData.gearboxType}
                                onChange={handleChange}
                            >
                                <option value="">Тип КПП</option>
                                <option value="Mechanic">Механическая</option>
                                <option value="Automatic">Автоматическая</option>
                                <option value="Stepless">Вариатор</option>
                                <option value="Robotic">Робот</option>
                            </select>
                        </div>
                        <div className="car-parameter add-desc">
                            <p>Цена</p>
                            <input type="number" name="pricePerUnit" value={formData.price} onChange={handleChange} required />
                        </div>
                        <div className="car-parameter add-desc">
                            <p>Описание</p>
                            <textarea name="description" value={formData.description} onChange={handleChange} required />
                        </div>
                        <div className='button-container add-desc'>
                            <button type="submit" className="submit-button add-desc">Сохранить</button></div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default AddAnnounce; 