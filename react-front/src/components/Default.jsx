import { loremIpsum } from 'lorem-ipsum';
import { data, Link } from 'react-router-dom';
import Header from './Header/Header'
import CarsList from './CarsList';
import Card from './CarCard/CarCard';


const Data = [
  {
    id: "1",
    pricePerUnit: 333,
    carName: "Lada",
    pathToImages: "http://localhost:5000/images/1/6/1.png",
    rating: "4,3",
    reviewsCount: 17,
    userAvatar: "http://localhost:5000/images/1/1.png"
  },
  {
    id: "2",
    pricePerUnit: 3500,
    carName: "fsaf sLada",
    pathToImages: "http://localhost:5000/images/2/1/1.png",
    rating: "4,1",
    reviewsCount: 2,
    userAvatar: "http://localhost:5000/images/2/1.png"
  },
  {
    id: "3",
    pricePerUnit: 5213,
    carName: "Ladaf sfasf",
    pathToImages: "http://localhost:5000/images/2/2/1.png",
    rating: "2,3",
    reviewsCount: 71,
    userAvatar: "http://localhost:5000/images/2/1.png"
  },
  {
    id: "4",
    pricePerUnit: 1000,
    carName: "Lasdsadsda",
    pathToImages: "http://localhost:5000/images/4/5/1.png",
    rating: "4,2",
    reviewsCount: 5,
    userAvatar: "http://localhost:5000/images/4/1.png"
  },
]

const Test = () => (
    <>
        <div className="header">
            <Link to="/" className="logo-link">
                <img src="../static/ion-logo.png" alt="ION" width="150" />
            </Link>
            <div className="user-buttons">
                <Link to="/chats" className="chats-link">Мои чаты</Link>
                <Link to="/profile" className="profile-link">
                    <img src="../static/UserLogo.png" alt="Фото профиля" width="50" />
                    <p>Годжу Сатору</p>
                </Link>
            </div>
        </div>
    </>
)

const BuildPage = (index) => (
  <>
    <Header/>
    <Card item={Data}/>
    <h3>Page {index}</h3>
    <div>
      Page {index} content: { loremIpsum({ count: 5 })}
    </div>
  </>
);

export const PageOne = () => BuildPage(1);
export const PageTwo = () => BuildPage(2);