export interface TokenDto {
  token: string;
  expiration: string;
  currentUser: ApplicationUserDto;
  isActive: boolean;
}
export interface ApplicationUserDto {
  userName: string | null;
  companyName: string | null;
  fullName: string | null;
  profilePicture: string | null;
}
