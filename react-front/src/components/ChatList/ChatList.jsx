import React from 'react';
import { Link } from 'react-router-dom';

const ChatList = ({ chats }) => {
    return (
        <div className="chats-list">
            {chats.map(chat => (
                <Link key={chat.id} to={`/announcement/${chat.announcementId}/chat`} className="chat">
                    <div className="avatar">
                        <img src={`http://localhost:5000/${chat.announcement.pathToImages}1.png`} height="130" width="130" alt="User Avatar" />
                        <div className="chat-info">
                            <p>{chat.sender.firstName} {chat.sender.lastName} - {chat.sender.phoneNumber}</p>
                            <p>{chat.announcement.carName} - {chat.announcement.pricePerUnit}</p>
                            <p>{chat.text}</p>
                        </div>
                    </div>
                </Link>
            ))}
        </div>
    );
};

export default ChatList; 