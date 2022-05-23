from lib.base_case import BaseCase
from lib.assertions import Assertions
from lib.my_requests import MyRequests


class TestEditUser(BaseCase):
    # Register
    def test_edit_created_user(self):
        register_data = self.prepare_registration_data()
        response = MyRequests.post("/user/", data=register_data)

        Assertions.assert_code_status(response, 200)
        Assertions.assert_json_has_key(response, "id")

        email = register_data["email"]
        password = register_data["password"]
        user_id = self.get_json_value(response, "id")

        # Login
        login_data = {
            "email": email,
            "password": password
        }
        response_2 = MyRequests.post("/user/login", data=login_data)
        auth_sid = self.get_cookie(response_2, "auth_sid")
        token = self.get_header(response_2, "x-csrf-token")

        # Edit
        new_name = "Changed Name"

        response_3 = MyRequests.put(
            f"/user/{user_id}",
            headers={"x-csrf-token": token},
            cookies={"auth_sid": auth_sid},
            data={"firstName": new_name}
        )

        Assertions.assert_code_status(response_3, 200)

        # Get
        response_4 = MyRequests.get(
            f"/user/{user_id}",
            headers={"x-csrf-token": token},
            cookies={"auth_sid": auth_sid}
        )

        Assertions.assert_json_value_by_name(
            response_4,
            "firstName",
            new_name,
            "Wrong First Name after editing the User"
        )
