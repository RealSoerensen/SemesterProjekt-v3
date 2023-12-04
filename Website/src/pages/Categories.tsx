import Card from '../components/Card/Card';
import { useCategory } from '../contexts/CategoryContext';

type Props = {}

const Categories = (props: Props) => {
  const { categories } = useCategory();

  return (
    <div className='container'>
      <div className='d-flex mx-auto justify-content-center my-5'>
        <h1>Categories</h1>
      </div>
      <div className='row'>
        <Card cards={categories} />
      </div>
    </div>
  )
}
export default Categories