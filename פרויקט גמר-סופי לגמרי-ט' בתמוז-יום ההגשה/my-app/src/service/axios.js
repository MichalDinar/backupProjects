
import axios from "axios"

const axiosInstance = axios.create({ baseURL: 'https://localhost:7182/api' })

export default axiosInstance
