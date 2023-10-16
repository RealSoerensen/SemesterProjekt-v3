import { useParams } from "react-router-dom";

const ProductPage = () => {
    const { id } = useParams<{ id: string }>();

    return (
        <div>
            ProductPage
            <br />
            id: {id}
        </div>
    )
}

export default ProductPage