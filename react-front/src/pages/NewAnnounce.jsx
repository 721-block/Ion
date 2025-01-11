import React, { useState } from 'react';
import Header from '../components/Header/Header';

const AddAnnounce = () => {
    const [formData, setFormData] = useState({
        carName: '',
        carModel: '',
        bodyType: '',
        price: '',
        description: '',
        files: []
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleFileChange = (e) => {
        setFormData({
            ...formData,
            files: e.target.files
        });
        console.log(newFiles);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log(formData);
        const formDataToSend = new FormData();
        for (const key in formData) {
            if (key === 'files') {
                Array.from(formData.files).forEach(file => {
                    formDataToSend.append('files', file);
                });
            } else {
                formDataToSend.append(key, formData[key]);
            }
        }

        try {
            const response = await fetch('http://localhost:5000/api/Announcement', {
                method: 'POST',
                body: formDataToSend
            });
            if (!response.ok) throw new Error('Failed to create announcement');
            alert('Announcement created successfully!');
        } catch (error) {
            console.error('Error creating announcement:', error);
        }
    };

    return (
        <div>
            <Header />
            <div className="main-container">
                <form className="car-data" onSubmit={handleSubmit}>
                    <h3>Марка и модель авто</h3>
                    <div className="car-parameter">
                        <p>Марка</p>
                        <input type="text" name="carName" value={formData.carMake} onChange={handleChange} required />
                    </div>
                    <div className="car-parameter">
                        <p>Модель</p>
                        <input type="text" name="carModel" value={formData.carModel} onChange={handleChange} required />
                    </div>
                    <div className="car-parameter">
                        <p>Тип кузова</p>
                        <input type="text" name="bodyType" value={formData.bodyType} onChange={handleChange} required />
                    </div>
                    <div className="car-parameter">
                        <p>Цена</p>
                        <input type="number" name="price" value={formData.price} onChange={handleChange} required />
                    </div>
                    <div className="car-parameter">
                        <p>Описание</p>
                        <textarea name="description" value={formData.description} onChange={handleChange} required />
                    </div>
                    <div className="car-images">
                        <input type="file" name="files" multiple onChange={handleFileChange} />
                    </div>
                    <button type="submit" className="submit-button">Сохранить</button>
                </form>
            </div>
        </div>
    );
};

export default AddAnnounce; 