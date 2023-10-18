import axios from "axios";
import baseURL from "./Constants";
import ProductDescription from "../models/ProductDescription";

const url = `${baseURL}/api/ProductDescription`;

export async function getAllProductDescription() {
    try {
        const response = await axios.get(`${url}`);

        if (response.status === 200) {
            return response.data;
        } else {
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}

export async function getProductDescriptionById(id: number): Promise<ProductDescription | null> {
    try {
        const response = await axios.get(`${url}/${id}`);

        if (response.status === 200) {
            // Assuming response.data.Image is the byte[] representing an image
            const productDescription: ProductDescription = response.data;
            // const imageBlob = new Blob([productDescription?.image], { type: 'image/jpeg' }); // Adjust the type as per your image format
            // const reader = new FileReader();
            // reader.readAsDataURL(imageBlob);

            // reader.onload = function () {
            //     // Here, reader.result will be a data URL that can be set as the src of an <img> element
            //     if (typeof reader.result === 'string')
            //         productDescription.image = reader.result; // You can add this new property to your ProductDescription class
            //     };
            return productDescription;

        } else {
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}
