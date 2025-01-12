import React, { useState, useEffect } from 'react';
import SearchForm from '../components/SearchForm';
import Map from '../components/Map';
import Header from '../components/Header/Header';
import CarCard from '../components/CarCard/CarCard';
import './Index.css';

const Index = () => {
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

            for(var k in data){
                const userResponse = await fetch(`http://721block.ru:5000/api/User/${data[k].authorId}`);
                let authorInfo = await userResponse.json();
                data[k]["author"] = authorInfo;
            }
            
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
        for(var k in data){
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
                <SearchForm onSearch={handleSearch} />
                <div className="main-content index">
                    <CarCard item={announcements} />
                    <Map announcements={announcements} />
                </div>
            </div>
        </div>
    );
};

export default Index; 