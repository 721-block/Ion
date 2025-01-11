import React, { useState, useEffect } from 'react';
import Header from '../components/Header/Header';
import ChatList from '../components/ChatList/ChatList';
import './Chats.css'

const Chats = () => {
    const [chats, setChats] = useState([]);

    useEffect(() => {
        fetchChats();
    }, []);

    const fetchChats = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/Message'); // Assuming there's an endpoint for fetching chats
            if (!response.ok) throw new Error('Failed to fetch chats');
            let data = await response.json();
            console.log(data);
            setChats(data);
        } catch (error) {
            console.error('Error fetching chats:', error);
        }
    };

    return (
        <div>
            <Header />
            <div className="main-container chats-page">
                <ChatList chats={chats} />
            </div>
        </div>
    );
};

export default Chats; 