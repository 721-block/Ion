import React, { useState, useEffect } from 'react';
import SearchForm from '../components/SearchForm';
import Header from '../components/Header/Header';
import CarCard from '../components/CarCard/CarCard';
import './Index.css';
import { YMaps, Map, ObjectManager, Placemark } from '@pbe/react-yandex-maps';

const Index = () => {
    const [carNames, setCarNames] = useState([]);
    const [announcements, setAnnouncements] = useState([]);
    const [filterParams, setFilterParams] = useState({
        bodyType: '',
        gearboxType: '',
        carMark: '',
        minPrice: '',
        maxPrice: ''
    });

    useEffect(() => {
        fetchAnnouncements();
    }, []);

    const getAnnouncements = async () => {
        let response = await fetch('http://721block.ru:5000/api/Announcement');
        return await response.json();
    }

    const fetchAnnouncements = async () => {
        try {
            let response = await fetch('http://721block.ru:5000/api/Announcement');
            let data = await response.json();

            for (var k in data) {
                const userResponse = await fetch(`http://721block.ru:5000/api/User/${data[k].authorId}`);
                let authorInfo = await userResponse.json();
                data[k]["author"] = authorInfo;
            }
            let carNames = data.map(item => item.carName).filter((value, index, self) => self.indexOf(value) === index);
            console.log(carNames);
            setCarNames(carNames);

            setAnnouncements(data);
        } catch (error) {
            console.error('Error fetching announcements:', error);
        }
    };

    const handleSearch = async (searchParams) => {
        const queryParams = new URLSearchParams(searchParams);
        const response = await fetch(`http://721block.ru:5000/api/Announcement/Search?${queryParams}`);
        if (!response.ok) throw new Error('Failed to search announcements');
        const data = await response.json();
        for (var k in data) {
            const userResponse = await fetch(`http://721block.ru:5000/api/User/${data[k].authorId}`);
            let authorInfo = await userResponse.json();
            data[k]["author"] = authorInfo;
        }
        setAnnouncements(data);
    };

    return (
        <div>
            <Header />
            <div className="main-container index">
                <SearchForm onSearch={handleSearch} carNames={carNames} />
                <div className="main-content index">
                    <CarCard item={announcements} />
                    <YMaps>
                        <div className="map-container index">
                            <Map className="map-map index" defaultState={{ center: [56.832299, 60.613234], zoom: 13 }}>
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
                                {
                                    announcements.map(announcement => (
                                        <Placemark geometry={[announcement.carLocation.x, announcement.carLocation.y]} properties={{
                                            balloonContent: () => '',
                                            iconCaption: `${announcement.carName} - ${announcement.pricePerUnit} руб` 
                                            
                                        }}options={{
                                                preset: 'islands#greenDotIconWithCaption',
                                                iconColor: '#aeca3b',
                                                controls: []
                                            }} />
                                    ))
                                }

                            </Map>
                        </div>
                    </YMaps>
                </div>
            </div>
        </div>
    );
};

export default Index; 