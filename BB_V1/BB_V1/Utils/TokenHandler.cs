using BB_V1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace BB_V1.Utils
{
    public static class TokenHandler
    {
        public static string GenerateTokenTaiKhoan(TaiKhoan tk, string secretKey)
        {
            var jwtTokenHanlder = new JwtSecurityTokenHandler();
            var secretKeyByte = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("username", tk.Username),
                    new Claim("matkhau", tk.MatKhau),
                    //new Claim("email", tk.Email),
                    new Claim("id", tk.ID_TK.ToString()),
                    //new Claim("tenloaitaikhoan", tk.LoaiTaiKhoan.TenLoai),
                    new Claim("id_loaitaikhoan", tk.ID_LTK.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyByte), SecurityAlgorithms.HmacSha512Signature)

            };
            var token = jwtTokenHanlder.CreateToken(tokenDescription);
            return jwtTokenHanlder.WriteToken(token);
        }

        public static string GenerateTokenHandler(TaiKhoan tk, string secretKey, string issuser)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var Claims = new[]
            {
                new Claim("id_tk", tk.ID_TK.ToString()),
                new Claim("username",tk.Username),
                new Claim("email",tk.Email)
            };

            var token = new JwtSecurityToken(
                issuer: issuser,
                audience: issuser,
                Claims,
                expires: DateTime.Now.AddDays(1),

                signingCredentials: credentials
                );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        public static TaiKhoan FilterToken(IIdentity identity)
        {
            ClaimsIdentity _identity = identity as ClaimsIdentity;
            IList<Claim> claims = _identity.Claims.ToList();

            TaiKhoan account = new TaiKhoan();

            account.ID_TK = new Guid(claims[0].Value);
            account.Username = claims[1].Value;
            account.Email = claims[2].Value;

            return account;
        }

        public static string GenerateTokenHandler(NguoiHienMau nhm, string secretKey, string issuser)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var Claims = new[]
            {
                new Claim("uid", nhm.UID.ToString()),
                new Claim("username",nhm.Username),
                new Claim("email",nhm.Email)
            };

            var token = new JwtSecurityToken(
                issuer: issuser,
                audience: issuser,
                Claims,
                expires: DateTime.Now.AddDays(1),

                signingCredentials: credentials
                );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        public static NguoiHienMau FilterTokenNguoiHienMau(IIdentity identity)
        {
            ClaimsIdentity _identity = identity as ClaimsIdentity;
            IList<Claim> claims = _identity.Claims.ToList();

            NguoiHienMau nhm = new NguoiHienMau();

            nhm.UID = new Guid(claims[0].Value);
            nhm.Username = claims[1].Value;
            nhm.Email = claims[2].Value;

            return nhm;
        }
    }
}
